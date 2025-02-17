namespace StudyBuddy.Core.Constants
{
   public struct ApiResponseMessages
   {
      public const string VALIDATION_ERRORS = "Validation errors!";
      public const string SOMETHING_WENT_WRONG = "Something went wrong!";
      public const string USER_ALREADY_EXISTS = "User already exists!";
      public const string PASSWORD_DOES_NOT_MATCH = "Password does not match!";
      public const string USER_REGISTERED_SUCCESSFULLY = "User registered successfully!";
      public const string INVALID_EMAIL_OR_PASSWORD = "Invalid email or password!";
      public const string WELCOME_BACK_MESSAGE = "Welcome back ";
      public const string INVALID_OTP_CODE_OR_EXPIRED = "Invalid OTP code or expired!";
      public const string EMAIL_HAS_BEEN_VERIFIED = "Email has been verified you can now login!";
      public const string OTP_CODE_SENT_SUCCESSFULLY = "Otp code sent succesfully!";
      public const string PASSWORD_RESET_SUCCESSFULLY = "Password reset successfully!";
      public const string USER_NOT_FOUND = "User not found!";
      public const string FAILED_TO_RESET_PASSWORD = "Failed to reset password!";
      public const string TERM_CREATED_SUCCESSFULLY = "Term created successfully!";
      public const string TERM_UPDATED_SUCCESSFULLY = "Term updated successfully!";
      public const string TERM_NOT_FOUND = "Term not found!";
      public const string NO_TERMS_FOUND = "No terms found!";
      public const string RECORD_FOUND = "Record found!";
      public const string COURSE_CREATED = "Course created successfully!";
      public const string COURSE_NAME_ALREADY_EXISTS_CHOOSE_ANY_OTHER = "Course name already exists choose any other!";
      public const string COURSE_NOT_FOUND = "Course not found!";
      public const string COURSE_UPDATED = "Course updated successfully!";
      public const string NO_RECORDS_FOUND = "No records found!";
      public const string TERM_DELETED_SUCCESSFULLY = "Term deleted successfully!";
      public const string SESSION_CREATED_SUCCESSFULLY = "Session created successfully!";
      public const string ACTIVITY_CREATED = "Activity created successfully!";
      public const string ACTIVITY_ALREADY_EXISTS = "Activity already exists with this name!";
      public const string ACTIVITY_UPDATED = "Activity updated successfully!";

      public const string SESSION_UPDATED_SUCCESSFULLY = "Session updated successfully!";
      public const string SESSION_DELETED_SUCCESSFULLY = "Session deleted successfully!";
      public const string ACTIVITY_DELETED_SUCCESSFULLY = "Activity deleted successfully!";
   }

   public struct OtpUseCases
   {
      public const string REGISTER_OTP = "ROTP";
      public const string LOGIN_OTP = "LOTP";
      public const string FORGOT_OTP = "FOTP";
      public const string VERIFY_EMAIL_OTP = "VOTP";
   }
}