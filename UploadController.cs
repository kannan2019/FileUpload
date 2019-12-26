        [Route("UploadDocument")]
        [HttpPost]
        public IActionResult UploadDocument(List<IFormFile> files)
        {
            try
            {
                var folderName = Path.Combine(_env.ContentRootPath, "Uploaded");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);               
                if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
                foreach (var file in files)
                {
                    var fileName = string.Concat(file.FileName);
                    var fullPath = Path.Combine(pathToSave, fileName);
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {               
                throw;
            }
        }
