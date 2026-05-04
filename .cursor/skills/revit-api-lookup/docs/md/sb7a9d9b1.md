---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionUtils.GetStructuralSection(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/7fcb5406-efef-64d1-fbb7-807396405132.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionUtils.GetStructuralSection Method

Return structural section from element.

## Syntax (C#)
```csharp
public static StructuralSection GetStructuralSection(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the family for beam, brace or structural column.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - ID of family symbol or family instance for beam, brace or structural column.

## Returns
Structural section returned if element have one.
 For elements that do not have structural section or can not have structural section Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned.

## Remarks
Only beams, braces and structural columns can have structural section associated with it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

