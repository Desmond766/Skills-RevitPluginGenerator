---
kind: method
id: M:Autodesk.Revit.DB.ViewFamilyType.IsValidDefaultTemplate(Autodesk.Revit.DB.ElementId)
source: html/f0d1b32d-8b7d-db6b-b7e9-393df29bd6bc.htm
---
# Autodesk.Revit.DB.ViewFamilyType.IsValidDefaultTemplate Method

Verifies that the input can be used as a default template for this view type.

## Syntax (C#)
```csharp
public bool IsValidDefaultTemplate(
	ElementId templateId
)
```

## Parameters
- **templateId** (`Autodesk.Revit.DB.ElementId`) - Id to be validated as default template.

## Returns
True if %templateId% is valid as default template, false otherwise.

## Remarks
The id must represent a template view that is compatible with this view type, or InvalidElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

