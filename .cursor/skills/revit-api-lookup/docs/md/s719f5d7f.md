---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeParameters.GetElementIdForExternalDefinition(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalDefinition)
source: html/888cb702-11cd-589a-0406-d6435f3e6116.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeParameters.GetElementIdForExternalDefinition Method

Retrieve the ElementId corresponding to an external rebar shape parameter
 in the document, if it exists; otherwise, return InvalidElementId.

## Syntax (C#)
```csharp
public static ElementId GetElementIdForExternalDefinition(
	Document doc,
	ExternalDefinition externalDefinition
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **externalDefinition** (`Autodesk.Revit.DB.ExternalDefinition`) - A shared parameter.

## Returns
An ElementId representing the shared parameter stored in the document,
 or InvalidElementId if the parameter is not stored in the document.

## Remarks
Before a parameter can be used in a RebarShapeDefinition, it must
 exist in the definition's document. There are two ways to achieve this.
 It can be bound to one or more categories in the document using
 the Document.ParameterBindings property, or it can be created by 
 calling RebarShapeParameters.GetOrCreateElementIdForExternalDefinition().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was Nothing nullptr a null reference ( Nothing in Visual Basic) .

