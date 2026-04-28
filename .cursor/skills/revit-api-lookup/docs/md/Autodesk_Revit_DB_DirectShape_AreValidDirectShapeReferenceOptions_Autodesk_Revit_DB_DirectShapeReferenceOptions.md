---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AreValidDirectShapeReferenceOptions(Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/eaa7ecd1-5a5b-2df4-8fbb-f1a890a2b41a.htm
---
# Autodesk.Revit.DB.DirectShape.AreValidDirectShapeReferenceOptions Method

Validates that the input DirectShapeReferenceOptions are suitable for creating a direct shape reference object.
 If the options specify an ExternalGeometryId, it must not correspond to any existing reference object
 belonging to the DirectShape.

## Syntax (C#)
```csharp
public bool AreValidDirectShapeReferenceOptions(
	DirectShapeReferenceOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.DirectShapeReferenceOptions`) - The options to test.

## Returns
True if the options can be used to add a reference object to this DirectShape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

