---
kind: type
id: T:Autodesk.Revit.DB.Parameter
zh: 参数、共享参数
source: html/333ff41b-e6a7-d959-60bf-c3bfae495581.htm
---
# Autodesk.Revit.DB.Parameter

**中文**: 参数、共享参数

The parameter object contains the value data assigned to that parameter.

## Syntax (C#)
```csharp
public class Parameter : APIObject
```

## Remarks
The piece of data contained within the parameter can be either a Double, Integer,
String or ElementId. The parameter object can be retrieved from any Element object using
either a built in id, definition object or shared parameter guid. All Elements within
Autodesk Revit contain Parameters. These are options that can be accessed in a generic
fashion. Revit contains many built in parameter types but users and now developers, via the
API, can add their own parameters in the form of shared parameters. The developer should
become familiar with the Revit user interface for added and managing parameters and shared
parameters before using this API. The user interface components can be found in the following
locations: Element Properties dialog, Shared Parameters dialog (available from the File menu),
Project Parameters dialog (available from the Settings menu), Family Types dialog (available
from the Settings menu when editing a family). There are several relationships between the
objects that make up the APIs exposure of parameters. The parameter object contains the data
value. Parameter objects can be retrieved from Elements if you know its built-in id,
its definition or its shared parameter guid. Each parameter has a definition. New parameters
can be added to Elements by adding a ParameterBinding object to the Document object.

