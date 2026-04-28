---
kind: property
id: P:Autodesk.Revit.DB.ColorFillSchemeEntry.FillPatternId
source: html/60eb8528-0a4b-e71a-a420-41ec39d020ae.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.FillPatternId Property

The id of fill pattern element of this entry.

## Syntax (C#)
```csharp
public ElementId FillPatternId { get; set; }
```

## Remarks
InvalidElementid represents no pattern, that means
 there would be nothing to be filled for elements colored based on this entry. Only fill pattern elements whose fill pattern target is drafting is valid for color fill scheme.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

