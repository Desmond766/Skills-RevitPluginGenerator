---
kind: method
id: M:Autodesk.Revit.DB.ImageTypeOptions.#ctor(Autodesk.Revit.DB.ExternalResourceReference,Autodesk.Revit.DB.ImageTypeSource)
source: html/df96413a-2ff3-128b-7276-28980e2689ce.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.#ctor Method

Constructs a new instance of the ImageTypeOptions object.

## Syntax (C#)
```csharp
public ImageTypeOptions(
	ExternalResourceReference resourceReference,
	ImageTypeSource sourceType
)
```

## Parameters
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An external resource reference to an image.
- **sourceType** (`Autodesk.Revit.DB.ImageTypeSource`) - Specifies the image type source. Valid values are 'Import' and 'Link'.

## Remarks
ImageTypeOptions uses an external resource reference to determine the local path that will be used
 to open the image file. The operation to obtain the local path requires the resource to be loaded and is
 performed at a later time when the local path is needed, for example, for validation. See also
 LoadResource method of IExternalResourceServer . When the provided external resource reference contains a local file path, the information can include
 an indication that the path should be treated as a relative path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ImageType source is not correct. Only Link or Import values are allowed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

