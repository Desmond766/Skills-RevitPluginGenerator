---
kind: method
id: M:Autodesk.Revit.DB.ImageTypeOptions.#ctor(System.String,System.Boolean,Autodesk.Revit.DB.ImageTypeSource)
source: html/7dda4131-548f-7c39-4dcd-ba9b85846018.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.#ctor Method

Constructs a new instance of the ImageTypeOptions object. The provided string path must specify a local file. The path can be absolute or relative
 to the project's location. This constructor saves an additional setting that indicates whether the imagetype
 will be a link or an import.

## Syntax (C#)
```csharp
public ImageTypeOptions(
	string path,
	bool useRelativePath,
	ImageTypeSource sourceType
)
```

## Parameters
- **path** (`System.String`) - The file path that specifies the image to be used.
- **useRelativePath** (`System.Boolean`) - True if ImageType should use a relative path, false otherwise.
- **sourceType** (`Autodesk.Revit.DB.ImageTypeSource`) - Specifies the image type source. Valid values are 'Import' and 'Link'.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ImageType source is not correct. Only Link or Import values are allowed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

