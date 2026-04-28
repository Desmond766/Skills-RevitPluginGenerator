---
kind: type
id: T:Autodesk.Revit.DB.ModelPath
source: html/40a84c72-e4b8-72ac-2f71-3216c66a11b3.htm
---
# Autodesk.Revit.DB.ModelPath

A path to a file stored on a disk or on a server.

## Syntax (C#)
```csharp
public class ModelPath : IDisposable
```

## Remarks
ModelPaths are paths to another file. They can
 refer to Revit models, or to any of Revit's external
 file references (DWG links, for example.)
Paths can be relative or absolute, but they must
 include an extension indicating what kind of file it is.
 Relative paths are generally relative to the currently
 opened document. If the current document is workshared,
 paths will be treated as relative to the central model.
To create a ModelPath, use the derived classes FilePath
 , ServerPath, or use
 [!:Autodesk::Revit::DB::ModelPathUtils::ConvertCloudGUIDsToCloudPath(System::Guid, System::Guid)] 
 for a cloud model path.
The class ModelPathUtils contains utility functions for
 converting ModelPaths to and from strings.

