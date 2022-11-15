namespace EducationSystem.Enums.Claims;

public class ManagerClaims
{
    #region User

    public const string GetProfile = "Users.Get.Profile";
    public const string GetProfileById = "Users.Get.Profile.ById";
    public const string GetUserById = "Users.Get.User.ById";
    public const string EditProfile = "Users.Put.Profile";
    public const string GetListUsers = "Users.Get.Users.List";
    public const string CreateUser = "Users.Post.User";
    public const string DeleteUserById = "Users.Delete.User.ById";
    public const string EditUser = "Users.Put.User";
    public const string GetListClaimsByUserId = "Users.Get.Claims.List.ByUserId";
    public const string DeleteClaimById = "Users.Delete.Claim.ById";
    public const string GetListClaims = "Users.Get.Claims.List";

    #endregion

    #region UserSettings
        
    public const string EditUserSettings = "UserSettings.Put.UserSettings";
    public const string EditUserSettingsById = "UserSettings.Put.UserSettings.ById";        
    public const string GetUserSettings = "UserSettings.Get.UserSettings";
    public const string GetUserSettingsById = "UserSettings.Get.UserSettings.ById";

    #endregion

    #region Product

    public const string UserTakeOrganization = "User.Take.Organization";
    public const string GetProductByCode = "Products.Get.Product.ByCode";
    public const string GetProductById = "Products.Get.Product.ById";
    public const string GetListProducts = "Products.Get.Products.List";
    public const string CreateProduct = "Products.Post.Product";
    public const string EditProduct = "Products.Put.Product";
    public const string DeleteProduct = "Products.Delete.Product";
    public const string CopyProduct = "Products.Post.Product.Copy";
    public const string UploadModels = "Products.Post.Models";
    public const string DeleteModels = "Products.Delete.Models";
    public const string EditStatusModels = "Products.Put.Status.Model";
    public const string UploadImages = "Products.Post.Images";
    public const string DeleteImages = "Products.Delete.Images";
    public const string CreateCode = "Products.Post.Code";
    public const string EditCodes = "Products.Put.Code";
    public const string DeleteCodes = "Products.Delete.Code";
    public const string AddTags = "Products.Post.Tags";
    public const string DeleteTag = "Products.Delete.Tag";
    public const string DeleteAllTags = "Products.Delete.Tags";
    public const string GetModelAndImages = "Products.Get.Model.Images.List";
        
    #endregion

    #region Category

    public const string GetCategoryById = "Category.Get.Category.ById";
    public const string GetListCategory = "Category.Get.Category.List";
    public const string CreateCategory = "Category.Post.Category";
    public const string EditCategory = "Category.Put.Category";
    public const string DeleteCategory = "Category.Delete.Category";

    #endregion

    #region CategoryFilter

    public const string GetFilterCategoryById = "CategoryFilter.Get.Filter.ById";
    public const string GetValuesFilterCategoryById = "CategoryFilter.Get.Values";
    public const string CreateFilterCategory = "CategoryFilter.Post.Filter";
    public const string DeleteFilterCategory = "CategoryFilter.Delete.Filter";
    public const string CreateValuesFilterCategory = "CategoryFilter.Post.Values";
    public const string DeleteValuesFilterCategory = "CategoryFilter.Delete.Values";

    #endregion

    #region Organizations

    public const string GetListOrganizations = "Organizations.Get.Organizations.List";
    public const string GetOrganizationById = "Organizations.Get.Organization.ById";
    public const string GetRequisitesById = "Organizations.Get.Requisites.ById";
    public const string GetListRequisites = "Organizations.Get.Requisites.List";
        
    #endregion

    #region OrganizationInfo

    // public const string GetOrganizationInfoById = "OrganizationInfo.Get.Info.ById";
    public const string GetOrganizationInfo = "OrganizationInfo.Get.Info";
    public const string CreateOrganizationInfo = "OrganizationInfo.Post.Info";
    public const string EditOrganizationInfo = "OrganizationInfo.Put.Info";
    public const string DeleteOrganizationInfo = "OrganizationInfo.Delete.Info";

    #endregion

    #region Tag

    public const string GetListTags = "Tags.Get.Tags.List";
    public const string CreateTags = "Tags.Post.Tag";
    public const string DeleteTags = "Tags.Delete.Tag";

    #endregion

    #region TariffPropertDic

    public const string GetTariffPropertyDic = "TariffProperty.Get.Property.ById";
    public const string GetListTariffPropertyDic = "TariffProperty.Get.Property.List";

    #endregion

    #region Download

    public const string DownloadModelByName = "Download.Get.Model.ByName";
    public const string DownloadModelById = "Download.Get.Model.ById";
    public const string DownloadFileById = "Download.Get.File.ById";
    public const string DownloadTechnicalSupportRequestsById = "Download.Get.Request.Files.ById";
        
    #endregion

    #region Statistic

    public const string GetHistoryUser = "Statistic.Get.HistoryUser";
    public const string GetHistoryUserById = "Statistic.Get.HistoryUser.ById";
    public const string GetViewsByDeviceOs = "Statistic.Get.Views.ByDeviceOs";
    public const string GetUniqueIp = "Statistic.Get.UniqueIp";
    public const string GetCountViewsInDay = "Statistic.Get.CountViewsInDay";
    public const string GetCountViewsInDayByDevice = "Statistic.Get.CountViewsInDay.ByDevice";
    public const string GetTopModels = "Statistic.Get.TopModels";
    public const string GetViewsByCategory = "Statistic.Get.Views.ByCategory";
    public const string GetAzureLogByCategory = "Statistic.Get.AzureLog";
    public const string PostAzureLogByCategory = "Statistic.Post.AzureLog";

    #endregion

    #region Tariffs

    public const string GetListTariffs = "Tariffs.Get.Tariffs.List";
    public const string GetTariffsById = "Tariffs.Get.Tariffs.ById";
    public const string CopyTariff = "TariffDictionary.Get.Tariff.ById";

    #endregion
        
    #region TariffOrganization

    public const string GetListTariffOrganization = "TariffOrganization.Get.Tariffs.List";
    public const string GetTariffOrganizationById = "TariffOrganization.Get.Tariffs.ById";
    public const string DownloadDocumentTariffOrganization = "TariffOrganization.Get.Tariff";

    #endregion

    #region Role

    public const string GetListRoles = "Role.Get.Roles.List";

    #endregion

    #region Widget

    public const string CreateWidget = "Widget.Post.Widget";
    public const string EditWidget = "Widget.Put.Widget";
    public const string DeleteWidget = "Widget.Delete.Widget";
    public const string GetWidgetById = "Widget.Get.Widget.ById";
    public const string GetWidgetList = "Widget.Get.Widget.List";
        
    public const string GetWidgetButtonList = "Widget.Button.Get.Widget.List";
    public const string GetWidgetButtonById = "Widget.Button.Get.Widget.ById";
        
    public const string EdithWidgetButton = "Widget.Button.Put.Widget";
    public const string CreateWidgetButton = "Widget.Button.Post.Widget";
    public const string DeleteWidgetButton = "Widget.Button.Delete.Widget";

    #endregion

    #region TechnicalSupportRequest

    public const string CreateTechnicalSupportRequest = "Requests.Post.Request";

    #endregion
        
    #region TechnicalSupportTheme

    public const string GetTechnicalSupportThemeById = "Themes.Get.Theme.ById";
    public const string GetListTechnicalSupportTheme= "Themes.Get.Theme.List";

    #endregion
        
    // #region ProductSelectionAssistantAnswer
    //
    // public const string CreateAnswer = "Answer.Post.Answer";
    // public const string GetAnswerById = "Answer.Get.Answer.ById";
    // public const string GetListAnswer = "Answer.Get.Answer.List";
    // public const string EditAnswerById = "Answer.Put.Answer.ById";
    // public const string DeleteAnswerById = "Answer.Delete.Answer.ById";
    //
    // #endregion
    //
    // #region ProductSelectionAssistantQuestions
    //
    // public const string CreateQuestions = "Questions.Post.Questions";
    // public const string GetQuestionsById = "Questions.Get.Questions.ById";
    // public const string GetListQuestions = "Questions.Get.Questions.List";
    // public const string EditQuestionsById = "Questions.Put.Questions.ById";
    // public const string DeleteQuestionsById = "Questions.Delete.Questions.ById";
    //
    // #endregion
    //
    // #region ProductSelectionAssistantSurvey
    //
    // public const string CreateSurvey = "Survey.Post.Survey";
    // public const string GetSurveyById = "Survey.Get.Survey.ById";
    // public const string GetListSurvey = "Survey.Get.Survey.List";
    // public const string EditSurveyById = "Survey.Put.Survey.ById";
    // public const string DeleteSurveyById = "Survey.Delete.Survey.ById";
    //
    // #endregion
    //
    // #region ProductSelectionAssistantSurveyProducts
    //
    // public const string CreateSurveyProducts = "SurveyProducts.Post.SurveyProducts";
    // public const string GetSurveyProductsById = "SurveyProducts.Get.SurveyProducts.ById";
    // public const string GetListSurveyProducts = "SurveyProducts.Get.SurveyProducts.List";
    // public const string EditSurveyProductsById = "SurveyProducts.Put.SurveyProducts.ById";
    // public const string DeleteSurveyProductsById = "SurveyProducts.Delete.SurveyProducts.ById";
    //
    // #endregion
        
    #region GlobalSearch

    public const string GetGlobalSearchRequest = "GlobalSearch.Get.GlobalSearch";

    #endregion
}