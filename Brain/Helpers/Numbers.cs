namespace Brainspace.Helpers
{
    using System.Collections.Generic;

    public static class Numbers
    {
        public static InputGoal Zero()
        {
            var inputGoal = new InputGoal();
            inputGoal.Goal = new List<double> { 0, 0, 0 };
            inputGoal.Input = new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
            return inputGoal;
        }

        public static InputGoal One()
        {
            var inputGoal = new InputGoal();
            inputGoal.Goal = new List<double> { 0, 0, 1 };
            inputGoal.Input = new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
            return inputGoal;
        }

        public static InputGoal Two()
        {
            var inputGoal = new InputGoal();
            inputGoal.Goal = new List<double> { 0, 1, 0 };
            inputGoal.Input = new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 0, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 0, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
            return inputGoal;
        }

        public static InputGoal Three()
        {
            var inputGoal = new InputGoal();
            inputGoal.Goal = new List<double> { 0, 1, 1 };
            inputGoal.Input = new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 0, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
            return inputGoal;
        }

        public static InputGoal Four()
        {
            var inputGoal = new InputGoal();
            inputGoal.Goal = new List<double> { 1, 0, 0 };
            inputGoal.Input = new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 0, 1, 1, 0, 1, 1,
                1, 0, 1, 1, 0, 1, 1,
                1, 0, 1, 1, 0, 1, 1,
                1, 0, 0, 0, 0, 0, 1,
                1, 1, 1, 1, 0, 1, 1,
                1, 1, 1, 1, 0, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
            return inputGoal;
        }
    }
}
