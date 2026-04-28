---
kind: type
id: T:Autodesk.Revit.DB.BindingMap
source: html/4ce777fb-ab30-6d15-d019-5b430223ac62.htm
---
# Autodesk.Revit.DB.BindingMap

The parameters BindingMap contains all the parameter bindings that exist in the
Autodesk Revit project.

## Syntax (C#)
```csharp
public class BindingMap : DefinitionBindingMap
```

## Remarks
The ParameterBindingsMap is available from the Document.ParameterBindings property. A
parameter binding is the way that a parameter definition is bound to elements within one
or more categories. This map can be used to interrogate existing bindings, but it can also
be used to generate new parameter bindings by using the Insert method.

