---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.#ctor(Autodesk.Revit.DB.StorageType)
source: html/bdc51109-355d-dc7d-9b43-c59ab1357479.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.#ctor Method

Creates new ColorFillSchemeEntry.

## Syntax (C#)
```csharp
public ColorFillSchemeEntry(
	StorageType storageType
)
```

## Parameters
- **storageType** (`Autodesk.Revit.DB.StorageType`) - The type of data that could be stored into this entry.

## Remarks
A new created ColorFillSchemeEntry should be assigned proper value before it is applied to a
 [!:Autodesk::Revit::DB::ColorFillScheme] . If the Color and
 Caption properties are not set, Revit will generate them automatically
 after the ColorFillSchemeEntry is applied to the ColorFillScheme.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

