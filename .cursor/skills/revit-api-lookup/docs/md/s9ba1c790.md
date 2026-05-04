---
kind: type
id: T:Autodesk.Revit.DB.ParameterElement
source: html/2ad60b36-07d6-6aed-62c7-89f388f05ffb.htm
---
# Autodesk.Revit.DB.ParameterElement

An Element that stores a user-defined parameter.

## Syntax (C#)
```csharp
public class ParameterElement : Element
```

## Remarks
Revit supports both built-in and user-defined parameters. Built-in parameters
 ship with the application, and they are not stored in Revit documents.
 User-defined parameters are dynamically created, and they are stored in the
 documents that use them, wrapped in ParameterElement objects. Different
 subclasses of ParemeterElement represent different kinds of user-defined
 parameters.

