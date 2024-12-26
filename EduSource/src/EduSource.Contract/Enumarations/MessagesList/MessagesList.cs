namespace EduSource.Contract.Enumarations.MessagesList;

public enum MessagesList
{
    [Message("This email has been registered", "auth_email_exists")]
    AuthEmailExistException,

    [Message("Registration failed, please register again", "auth_register_failure")]
    AuthRegisterFailure,

    [Message("Registration successful, please check email for confirmation", "auth_register_success")]
    AuthRegisterSuccess,

    [Message("Registration time has passed, please register again", "auth_noti_01")]
    AuthRegisterTimeOutException,

    [Message("Account confirmation successful", "auth_noti_04")]
    VerifyEmailSuccess,

    [Message("Registration successful, you can now login", "auth_verify_success")]
    AuthVerifyEmailRegister,

    [Message("Your email is not registered", "auth_not_regist")]
    AuthEmailNotExsitException,

    [Message("This account was registered using another method", "auth_regis_another")]
    AuthAccountRegisteredAnotherMethod,

    [Message("Passwords do not match", "auth_password_not_match")]
    AuthPasswordNotMatchException,

    [Message("Your account has been banned", "account_banned")]
    AccountBanned,

    [Message("Logout successfully", "auth_logout_success")]
    AuthLogoutSuccess,

    [Message("Session has expired, please log in again", "auth_login_expired")]
    AuthRefreshTokenNull,

    [Message("Login Google fail, please try again", "auth_noti_09")]
    AuthLoginGoogleFail,

    [Message("Your OTP does not match", "auth_otp_01")]
    AuthOtpForgotPasswordNotMatchException,

    [Message("Unable to change password, please try again", "auth_forgot_01")]
    AuthErrorChangePasswordException,

    [Message("Please check your email to enter otp", "auth_noti_05")]
    AuthForgotPasswordEmailSuccess,

    [Message("Please fill new password to change", "auth_noti_06")]
    AuthForgotPasswordOtpSuccess,

    [Message("Your account password has been changed successfully.", "auth_noti_07")]
    AuthForgotPasswordChangeSuccess,

    [Message("This email is already registered with Google", "auth_email_03")]
    AuthGoogleEmailRegisted,

    [Message("Can not find this account!", "account_noti_exception_01")]
    AccountNotFoundException,
}
