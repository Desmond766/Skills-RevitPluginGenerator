---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionUtils.SetStructuralSection(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSection)
source: html/599df6e4-0398-22fa-4d72-feec51167f49.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionUtils.SetStructuralSection Method

Set structural section in element.

## Syntax (C#)
```csharp
public static bool SetStructuralSection(
	Document document,
	ElementId familySymbolId,
	StructuralSection structuralSection
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the family for beam, brace or structural column.
- **familySymbolId** (`Autodesk.Revit.DB.ElementId`) - ID of family symbol for beam, brace or structural column.
- **structuralSection** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSection`) - Structural section with values that will be set.

## Returns
True is returned when requested shape with values was properly set. Return false otherwise.

## Remarks
Only beams, braces and structural columns can have structural section associated with it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

