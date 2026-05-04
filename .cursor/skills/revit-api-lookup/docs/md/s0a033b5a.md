---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AreValidDirectShapeReferenceOptions(Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/44ada8e9-7445-7be1-a2d8-b37b3c256136.htm
---
# Autodesk.Revit.DB.DirectShapeType.AreValidDirectShapeReferenceOptions Method

Validates that the input DirectShapeReferenceOptions are suitable for creating a direct shape reference object.
 If the options specify an ExternalGeometryId, it must not correspond to any existing reference object
 belonging to the DirectShapeType.

## Syntax (C#)
```csharp
public bool AreValidDirectShapeReferenceOptions(
	DirectShapeReferenceOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.DirectShapeReferenceOptions`) - The options to test.

## Returns
True if the options can be used to add a reference object to this DirectShapeType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

