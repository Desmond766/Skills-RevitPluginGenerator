---
kind: method
id: M:Autodesk.Revit.DB.ImageTypeOptions.SetPath(System.String,System.Boolean)
source: html/9c707780-4777-d34b-adbc-3092b10b42bd.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.SetPath Method

Update the path of the file that specifies the image to be used. The provided string path must specify a local file. The path can be absolute or relative
 to the project's location. Additionally, indicate whether the path used by ImageType should be absolute or relative.

## Syntax (C#)
```csharp
public void SetPath(
	string path,
	bool useRelativePath
)
```

## Parameters
- **path** (`System.String`) - The file path that specifies the image to be used.
- **useRelativePath** (`System.Boolean`) - True if ImageType should use a relative path, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

