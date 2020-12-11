namespace Core
{
    public struct BaseValidationResult
    {
        public string Message { get; set; }

        public LevelTypes Level { get; set; }

        public bool IsValid { get; set; }

        public enum LevelTypes
        {
            Error = 1,
            Warning = 2,
            Info = 3
        }

        public static BaseValidationResult Error(string message)
        {
            return new BaseValidationResult
            {
                Level = LevelTypes.Error,
                Message = message,
                IsValid = false
            };
        }

        public static BaseValidationResult Warning(string message)
        {
            return new BaseValidationResult
            {
                Level = LevelTypes.Warning,
                Message = message,
                IsValid = true
            };
        }

        public static BaseValidationResult Info(string message)
        {
            return new BaseValidationResult
            {
                Level = LevelTypes.Info,
                Message = message,
                IsValid = true
            };
        }
    }
}
