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

        public int DirectionX { get; set; }
        public int DirectionZ { get; set; }

        public bool Enable { get; set; }

        public int HorizontalVelocity { get; set; }
        public int VerticalVelocity { get; set; }
        public Vector3 EnemyPosition { get; set; }

        private int indexerX;
        private int indexerZ;

        /// <summary>
        /// Main logic to vibrate shipspace. This method count and evaluate direction movement during the vibration.
        /// </summary>
        public void Vibrate()
        {
            if (OnChangeX)
            {
                DirectionX = (int)SetVibrateDirection();
                ResetIndexerX();
            }

            if (OnChangeZ)
            {
                DirectionZ = (int)SetVibrateDirection();
                ResetIndexerZ();
            }

            CheckFullIndexer();
            CheckEdgeMap();

            indexerX++;
            indexerZ++;
        }


        public EnemyVibration()
        {
            DirectionX = 0;
            DirectionZ = 0;
            OnChangeX = true;
            OnChangeZ = true;
            indexerX = 0;
            indexerZ = 0;
            HorizontalVelocity = EnemyHelper.VibrationVelocityX;
            VerticalVelocity = EnemyHelper.VibrationVelocityZ;
        }


        public void InitializeVibration()
        {
            DirectionX = 0;
            DirectionZ = 0;
            OnChangeX = true;
            OnChangeZ = true;
            indexerX = 0;
            indexerZ = 0;
        }

        
        /// <summary>
        /// Draws the direction vibration space
        /// </summary>
        /// <returns></returns>
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
        /// Check that enemy ship exceeded the allowed border. When isn't in correctly place change direction flight.
        /// </summary>
        private void CheckEdgeMap()
        {
            if(!CheckBorderX())
            {
                ChangeDirectionX();
            }
            if (!CheckBorderZ())
            {
                ChangeDirectionZ();
            }

        }

        /// <summary>
        /// Check that enemyship exceeded the allowed border on X-axis
        /// </summary>
        /// <returns></returns>
        private bool CheckBorderX()
        {
            return EnemyPosition.x <= EnemyHelper.EnemyBorderRight
                && EnemyPosition.x >= EnemyHelper.EnemyBorderLeft
                ? true : false;  
        }


        /// <summary>
        /// Check that enemyship exceeded the allowed border on Z-axis
        /// </summary>
        /// <returns></returns>
        private bool CheckBorderZ()
        {
            return EnemyPosition.z <= EnemyHelper.EnemyBorderTop &&
                EnemyPosition.z >= EnemyHelper.EnemyBorderBottom
                ? true:false;
           
        }


        /// <summary>
        /// Forces change direction on X-axis. Notice: Border can change for this same direction.
        /// </summary>
        private void ChangeDirectionX()
        {
            OnChangeX = true;
        }

        /// <summary>
        /// Forces change direction on Z-axis. Notice: Border can change for this same direction.
        /// </summary>
        private void ChangeDirectionZ()
        {
            OnChangeZ = true;
        }



        /// <summary>
        /// Check when vibration indexers has maximum value. When has set condition OnChange to rue value
        /// </summary>
        private void CheckFullIndexer()
        {
            OnChangeX = indexerX >= EnemyHelper.VibrationFrequencyX ? true : false;
            OnChangeZ = indexerZ >= EnemyHelper.VibrationFrequencyZ ? true : false;
        }

        
        private void ResetIndexerZ()
        {
            indexerZ = 0;
        }
        private void ResetIndexerX()
        {
            indexerX = 0;
        }

    }
}
