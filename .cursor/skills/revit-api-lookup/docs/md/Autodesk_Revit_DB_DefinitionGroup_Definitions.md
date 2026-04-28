---
kind: property
id: P:Autodesk.Revit.DB.DefinitionGroup.Definitions
source: html/d26a47b8-aa3f-8f0e-d2ce-4e66e5be07b2.htm
---
# Autodesk.Revit.DB.DefinitionGroup.Definitions Property

The Definitions property returns an object that contains all the shared parameter
definitions within the group.

## Syntax (C#)
```csharp
public Definitions Definitions { get; }
```

## Remarks
A known definition can be retrieved, by name, using the Item property on the Definitions
object. A new definition can be created by using the Create method. The Create method takes two
parameters, a string for name and a type. If the creation of the definition was successful then
an object representing the definition is returned by the Create method.

