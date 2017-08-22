using UnityEngine;

namespace Assets.LogicModel.Enemy
{
    public class EnemyVibration
    {
        /// <summary>
        /// Change X direction movement when ship is vibrate
        /// </summary>
        public bool OnChangeX { get; set; }

        /// <summary>
        /// Change Z direction movement when ship is vibrate
        /// </summary>
        public bool OnChangeZ { get; set; }

        public int IndexerX { get; set; }

        public int IndexerZ { get; set; }

        public int DirectionX { get; set; }

        public int DirectionZ { get; set; }
        public bool Enable { get; set; }


        public EnemyVibration()
        {
            DirectionX = 0;
            DirectionZ = 0;
            OnChangeX = true;
            OnChangeZ = true;
            IndexerX = 0;
            IndexerZ = 0;
        }

        public enum DirectionMovement
        {
            left = -1, none, right
        }

        public DirectionMovement SetDirectionVibrate()
        {
            int randomMode = Random.Range(0, 1000) % 3;
            switch (randomMode)
            {
                case 1:
                    return DirectionMovement.left;
                case 2:
                    return DirectionMovement.right;
                default:
                    return DirectionMovement.none;
            }
        }

    }
}
