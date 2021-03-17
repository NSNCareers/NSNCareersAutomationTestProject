namespace PageObjectFramework.Pages.Interfaces
{
    public interface IUserAccountPage
    {
        string GetPageTitel();
        bool VerifyElementDisplayed(string selector);
        T ClickOnLogoutButton<T>() where T : class;
        T ClickOnLoginLink<T>() where T : class;
        void ClickOnUserEmail();
        void EnterTelephoneNumber(string number);
        void ClickOnSaveButton();
        void EnterNewEmail(string newEmail);
        void ClickOnChangeEmailButton();
        void ClickEmailButton();
        bool VerifyManageEmailText(string emailText);
        bool VerifyProfileText(string profileText);
        bool VerifyWarningMessage(string emailText);
        void ClickDownloadButton();
        void ClickPersonalDataButton();
    }
}
