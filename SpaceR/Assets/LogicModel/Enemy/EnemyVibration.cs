using Assets.Helper;
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

        public int HorizontalVelocity { get; set; }
        public int VerticalVelocity { get; set; }


        /// <summary>
        /// Main logic to vibrate shipspace. This method count and evaluate direction movement during the vibration.
        /// </summary>
        public void Vibrate()
        {
            if (OnChangeX)
            {
                DirectionX = (int)SetVibrateDirection();
                ResertIndexerX();
            }

            if (OnChangeZ)
            {
                DirectionZ = (int)SetVibrateDirection();
                ResertIndexerZ();
            }

            CheckFullIndexer();

            IndexerX++;
            IndexerZ++;
        }


        public EnemyVibration()
        {
            DirectionX = 0;
            DirectionZ = 0;
            OnChangeX = true;
            OnChangeZ = true;
            IndexerX = 0;
            IndexerZ = 0;
            HorizontalVelocity = EnemyHelper.VibrationVelocityX;
            VerticalVelocity = EnemyHelper.VibrationVelocityZ;
        }


        public void InitializeVibration()
        {
            DirectionX = 0;
            DirectionZ = 0;
            OnChangeX = true;
            OnChangeZ = true;
            IndexerX = 0;
            IndexerZ = 0;
        }

        

        public EnumHelper.HorizontalDirectionMovement SetVibrateDirection()
        {
            int randomMode = Random.Range(0, 1000) % 3;
            switch (randomMode)
            {
                case 1:
                    return EnumHelper.HorizontalDirectionMovement.left;
                case 2:
                    return EnumHelper.HorizontalDirectionMovement.right;
                default:
                    return EnumHelper.HorizontalDirectionMovement.none;
            }
        }

        

        /// <summary>
        /// Check when vibration indexers has maximum value. When has set condition OnChange to rue value
        /// </summary>
        private void CheckFullIndexer()
        {
            OnChangeX = IndexerX >= EnemyHelper.VibrationFrequencyX ? true : false;
            OnChangeZ = IndexerZ >= EnemyHelper.VibrationFrequencyZ ? true : false;
        }

        private void ResertIndexerZ()
        {
            IndexerZ = 0;
        }
        private void ResertIndexerX()
        {
            IndexerX = 0;
        }

    }
}
