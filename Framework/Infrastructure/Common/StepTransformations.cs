//namespace Dropbox.Api.Tests
//{
//    using TechTalk.SpecFlow;
//    using TechTalk.SpecFlow.Assist;
//    using TestDropboxApi.DataModels;

//    [Binding]
//    public class StepTransformations
//    {
//        [StepArgumentTransformation]
//        public UploadFileDto ToUploadFileDto(Table table)
//        {
//            return table.CreateInstance<UploadFileDto>();
//        }

//        [StepArgumentTransformation]
//        public FileResponseDto ToFileResponseDto(Table table)
//        {
//            return table.CreateInstance<FileResponseDto>();
//        }

//        [StepArgumentTransformation]
//        public CreateFolderDto ToCreateFolderDto(Table table)
//        {
//            return table.CreateInstance<CreateFolderDto>();
//        }
//        [StepArgumentTransformation]
//        public FileListDto ToFileListDto(Table table)
//        {
//            return table.CreateInstance<FileListDto>();
//        }
//        [StepArgumentTransformation]
//        public DeleteFolderDto ToDeleteFolder(Table table)
//        {
//            return table.CreateInstance<DeleteFolderDto>();
//        }
//    }
//}
