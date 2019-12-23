using BS_Utils.Utilities;
using System.Linq;
using UnityEngine;

namespace DarthMaulCompetitive
{
    public class DarthMaulCompetitiveBehavior : MonoBehaviour
    {
        private PlayerController _playerController;
        private ConfigOptions config = ConfigOptions.instance;

        /// <summary>
        /// To be invoked every time when starting the GameCore scene.
        /// </summary>
        /// <remarks>
        /// Note that no delay is done with this method
        /// </remarks>
        public void BeginGameCoreScene()
        {
            if (config.IsTwoControllers || config.IsOneHanded)
            {
                this.TransformToNoArrowsScoring();
            }
        }

        private void Awake()
        {
            this._playerController = FindObjectOfType<PlayerController>();
            if (this._playerController == null) Logging.Warning("Unable to get the PlayerController object");
        }

        private void Update()
        {
            if (_playerController == null || !config.IsTwoControllers && !config.IsOneHanded)
            {
                return;
            }

            float separation = 1f * config.Separation / 100;

            if (config.IsOneHanded)
            {
                Saber baseSaber = config.UseLeftController ? _playerController.rightSaber : _playerController.leftSaber;
                Saber otherSaber = config.UseLeftController ? _playerController.leftSaber : _playerController.rightSaber;
                Saber rotateSaber = config.ReverseDirection ? otherSaber : baseSaber;

                // First set the position of the sabers to be the same
                baseSaber.transform.localPosition = otherSaber.transform.localPosition;
                baseSaber.transform.localRotation = otherSaber.transform.localRotation;

                // Rotate and separate the 'other' saber
                rotateSaber.transform.Rotate(0, 180, 180);
                rotateSaber.transform.Translate(0, 0, separation * 2, Space.Self);
            }
            else
            {
                Vector3 leftHandPos = _playerController.leftSaber.transform.position;
                Vector3 rightHandPos = _playerController.rightSaber.transform.position;
                Vector3 middlePos = (rightHandPos + leftHandPos) * 0.5f;
                Vector3 forward = (rightHandPos - leftHandPos).normalized;

                if (config.ReverseDirection)
                {
                    _playerController.rightSaber.transform.position = middlePos + -forward * separation;
                    _playerController.leftSaber.transform.position = middlePos + forward * separation;
                    _playerController.rightSaber.transform.rotation = Quaternion.LookRotation(-forward, _playerController.rightSaber.transform.up);
                    _playerController.leftSaber.transform.rotation = Quaternion.LookRotation(forward, _playerController.rightSaber.transform.up);
                }
                else
                {
                    _playerController.rightSaber.transform.position = middlePos + forward * separation;
                    _playerController.leftSaber.transform.position = middlePos + -forward * separation;
                    _playerController.rightSaber.transform.rotation = Quaternion.LookRotation(forward, _playerController.rightSaber.transform.up);
                    _playerController.leftSaber.transform.rotation = Quaternion.LookRotation(-forward, _playerController.rightSaber.transform.up);
                }
            }
        }

        private void TransformToNoArrowsScoring()
        {
            const string NoArrowsModeName = "NoArrows";

            // Check for game mode and early exit on One Saber or NoArrows
            GameplayCoreSceneSetupData data = BS_Utils.Plugin.LevelData?.GameplayCoreSceneSetupData;
            var beatmap = data.difficultyBeatmap;
            string serializedName = beatmap.parentDifficultyBeatmapSet.beatmapCharacteristic.serializedName;
            if (serializedName == NoArrowsModeName)
            {
                // Do not transform for No Arrows mode
                Logging.Info($"No need to transform: {beatmap.level.songName} for Darth Maul Competitive as it is already a No Arrows map");
                return;
            }

            // Get the in memory beat map
            BeatmapObjectCallbackController callbackController = Resources.FindObjectsOfTypeAll<BeatmapObjectCallbackController>().First();
            BeatmapData beatmapData = callbackController.GetField<BeatmapData>("_beatmapData");

            // Transform the map to No Arrows
            foreach (BeatmapLineData line in beatmapData.beatmapLinesData)
            {
                var objects = line.beatmapObjectsData;
                foreach (BeatmapObjectData beatmapObject in objects)
                {
                    if (beatmapObject.beatmapObjectType == BeatmapObjectType.Note)
                    {
                        var note = beatmapObject as NoteData;
                        note.SetNoteToAnyCutDirection();
                    }
                }
            }
        }
    }
}
