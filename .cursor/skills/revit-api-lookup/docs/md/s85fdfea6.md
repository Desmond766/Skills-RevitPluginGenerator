---
kind: method
id: M:Autodesk.Revit.DB.Element.IsExternalFileReference
zh: 构件、图元、元素
source: html/2bf6162f-0b0f-88cb-9c67-d4bd435537b5.htm
---
# Autodesk.Revit.DB.Element.IsExternalFileReference Method

**中文**: 构件、图元、元素

Determines whether this Element represents an external
 file.

## Syntax (C#)
```csharp
public bool IsExternalFileReference()
```

## Returns
True if this element contains information about some external
 file, false if it does not.

## Remarks
Linked files are references to external files, but
 imported files are not, as their data is brought wholly into
 Revit.

