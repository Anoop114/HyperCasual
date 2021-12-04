using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Avoidance
{
    /// <summary>
    /// Responsible for posting a score to the Google Play leaderboard and showing the leaderboard UI.
    /// </summary>
    public class GPLeaderboard : Singleton<GPLeaderboard>
    {
        /// <summary>
        /// Posts the score if on Android platform.
        /// </summary>
        /// <param name="score">Score.</param>
        public void PostScore(int score)
        {
            Debug.Log("Add code to post score to leaderboard here");
        }

        /// <summary>
        /// Shows the Android leaderboard UI.
        /// </summary>
        public void ShowUI()
        {
            Debug.Log("Add code to show leaderboard here");
        }
    }
}