using System;
using TextEditor._BL;
using TextEditor._BL.Interfaces;
using TextEditor.Interfaces;

namespace TextEditor
{
    public class Presenter
    {
        private readonly IFileManager _manager;
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;

        private string _currentFilePath;
        
        public Presenter(IMainForm form, IFileManager manager, IMessageService service)
        {
            _view = form;
            _manager = manager;
            _messageService = service;
            
            _view.SetSymbolCount(0);
            
            _view.ChangeContent += ViewOnChangeContent;
            _view.FileOpenClick += ViewOnFileOpenClick; 
            _view.FileSaveClick += ViewOnFileSaveClick;
        }

        private void ViewOnFileSaveClick(object? sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;
                _manager.SaveContent(_currentFilePath, content);
                _messageService.ShowMessage("File was saved!");
            }
            catch (Exception exception)
            {
                _messageService.ShowError(exception.Message);
            }
        }

        private void ViewOnFileOpenClick(object? sender, EventArgs e)
        {
            try
            {
                string filePath = _view.FilePath;
                if (!_manager.IsExist(filePath))
                {
                    _messageService.ShowExclamation("File does not exist!");
                    return;
                }

                _currentFilePath = filePath;

                string content = _manager.GetContent(filePath);
                int count = _manager.GetSymbolCount(content);

                _view.Content = content;
                _view.SetSymbolCount(count);

            }
            catch (Exception exception)
            {
                _messageService.ShowError(exception.Message);
            }
        }

        private void ViewOnChangeContent(object? sender, EventArgs e)
        {
            string content = _view.Content;
            int count = _manager.GetSymbolCount(content);
            _view.SetSymbolCount(count);
        }
        
        
    }
}