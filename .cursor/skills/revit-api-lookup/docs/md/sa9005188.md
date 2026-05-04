---
kind: property
id: P:Autodesk.Revit.DB.ColorFillSchemeEntry.Caption
source: html/b0d11e7a-c253-a4a9-3d20-ec47577c78dd.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.Caption Property

The text displayed in [!:Autodesk::Revit::DB::ColorFillLegend] for this entry.

## Syntax (C#)
```csharp
public string Caption { get; set; }
```

## Remarks
This property is only meaningful for by range scheme.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: newCaption is an empty string or contains only whitespace.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

