---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationType.CreateDefault(Autodesk.Revit.DB.Document)
source: html/25edda1f-9be3-5f7e-2d3b-255293c08b2a.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationType.CreateDefault Method

Creates the first MultiReferenceAnnotationType element and adds it to the document.

## Syntax (C#)
```csharp
public static MultiReferenceAnnotationType CreateDefault(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to be modified.

## Returns
The new MultiReferenceAnnotationType element.

## Remarks
If there is no existing MultiReferenceAnnotationType a new one will be created, otherwise an exception will be thrown.
 Use Duplicate(String) to create all further MultiReferenceAnnotationTypes.
 The default MultiReferenceAnnotationType will use the document's current default
 linear dimension style and will have Structural Rebar as its reference category.
 No tag type will be set for the new MultiReferenceAnnotationType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 There are existing MultiReferenceAnnotationTypes in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

