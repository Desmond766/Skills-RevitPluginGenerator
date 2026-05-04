---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.CopyModel(Autodesk.Revit.DB.ModelPath,System.String,System.Boolean)
source: html/72fdfc1b-ae4b-1474-1b22-1c050193dc41.htm
---
# Autodesk.Revit.ApplicationServices.Application.CopyModel Method

Copies an existing model to a new file. Overwriting a file of the same name is allowed.

## Syntax (C#)
```csharp
public void CopyModel(
	ModelPath sourceModelPath,
	string destFilePath,
	bool overwrite
)
```

## Parameters
- **sourceModelPath** (`Autodesk.Revit.DB.ModelPath`) - The path of the file-based or server-based source model.
- **destFilePath** (`System.String`) - The path of the destination file.
- **overwrite** (`System.Boolean`) - True if the destination file can be overwritten; otherwise, false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given path sourceModelPath is a cloud path which is not supported in this method.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is missing.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.DirectoryNotFoundException** - Thrown when the directory of destination file doesn't exist.
- **Autodesk.Revit.Exceptions.FileArgumentAlreadyExistsException** - The destination file exists and can't be overwritten.
 -or-
 destFilePath is pointing to a folder that already exists and cannot be deleted.
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The Revit model specified by sourceModelPath doesn't exist.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The destination file name includes one or more invalid characters.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.

