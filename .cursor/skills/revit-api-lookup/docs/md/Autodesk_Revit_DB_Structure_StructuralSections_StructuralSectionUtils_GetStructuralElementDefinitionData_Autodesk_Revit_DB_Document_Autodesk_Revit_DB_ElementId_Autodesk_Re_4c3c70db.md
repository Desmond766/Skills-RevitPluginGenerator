---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionUtils.GetStructuralElementDefinitionData(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.StructuralSections.StructuralElementDefinitionData@)
source: html/f7ea435a-378e-1d3c-6f26-12fcfec15c7d.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionUtils.GetStructuralElementDefinitionData Method

Return structural element definition data.

## Syntax (C#)
```csharp
public static StructuralSectionErrorCode GetStructuralElementDefinitionData(
	Document document,
	ElementId elementId,
	out StructuralElementDefinitionData data
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the beam, brace or structural column.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - ID of family instance for beam, brace or structural column.
- **data** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralElementDefinitionData %`) - Structural element definition data.

## Returns
Success code is returned if StructuralElementDefinitionData was provided successfully, error code otherwise.

## Remarks
This information is provided only for beams, braces and structural columns.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

