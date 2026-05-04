---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.GetSketchGalleryOptions(Autodesk.Revit.DB.FamilySymbol)
source: html/3324ef29-2fd8-1760-f47a-030f5e2ccb2f.htm
---
# Autodesk.Revit.UI.UIDocument.GetSketchGalleryOptions Method

Gets the valid sketch gallery options of a family symbol.

## Syntax (C#)
```csharp
public IList<SketchGalleryOptions> GetSketchGalleryOptions(
	FamilySymbol familySymbol
)
```

## Parameters
- **familySymbol** (`Autodesk.Revit.DB.FamilySymbol`) - The family symbol.

## Returns
The valid list of SketchGalleryOptions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

