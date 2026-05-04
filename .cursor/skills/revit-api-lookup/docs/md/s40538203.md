---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeParameters.GetOrCreateElementIdForExternalDefinition(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalDefinition)
source: html/f933744c-5bf3-3bd0-c65e-23b627f4c236.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeParameters.GetOrCreateElementIdForExternalDefinition Method

Retrieve the ElementId corresponding to an external rebar shape parameter
 in the document, if it exists; otherwise, add the parameter to the document
 and generate a new ElementId.

## Syntax (C#)
```csharp
public static ElementId GetOrCreateElementIdForExternalDefinition(
	Document doc,
	ExternalDefinition externalDefinition
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **externalDefinition** (`Autodesk.Revit.DB.ExternalDefinition`) - A shared parameter.

## Returns
An ElementId representing the shared parameter stored in the document.

## Remarks
Before a parameter can be used in a RebarShapeDefinition, it must
 exist in the definition's document. There are two ways to achieve this.
 It can be bound to one or more categories in the document using
 the Document.ParameterBindings property, or it can be created with this
 method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was Nothing nullptr a null reference ( Nothing in Visual Basic) .

