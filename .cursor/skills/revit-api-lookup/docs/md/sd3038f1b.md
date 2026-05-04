---
kind: type
id: T:Autodesk.Revit.DB.DirectShapeLibrary
source: html/07489bae-ab9f-e2a8-0ac1-0a4d70cea458.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary

DirectShapeLibrary is used to store pre-created geometry for further referencing via the definition/instance mechanism.
 It is not persistent: the scope of a library object is usually a single data creation session.
 DirectShape::createGeometryInstance and DirectShape::CreateElementInstance will use the current DirectShapeLibrary to
 look up the definitions.
 store a collection of GNodes as definition
 end class DirectShapeDefinition

## Syntax (C#)
```csharp
public class DirectShapeLibrary : IDisposable
```

## Remarks
There are two ways to add a definition to the library. The first is to add the definition as an array of geometry objects.
 A DirectShape created as an instance of that definition will hold a copy of predefined geometry, transformed as requested.
 If the definition was added as a DirectShapeType, a DirectShape object created as an instance of that definition will reference the type.
 Its geometry would be an instance of type geometry.

