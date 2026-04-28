---
kind: method
id: M:Autodesk.Revit.DB.ImageTypeOptions.SetPath(System.String)
source: html/3eeb55a9-ced3-165d-5a9e-d75a9d7f2f20.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.SetPath Method

Update the path of the file that specifies the image to be used. The provided string path must specify a local file. The path can be absolute or relative
 to the project's location. ImageType will respectively use an absolute or relative path.

## Syntax (C#)
```csharp
public void SetPath(
	string path
)
```

## Parameters
- **path** (`System.String`) - The file path that specifies the image to be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

