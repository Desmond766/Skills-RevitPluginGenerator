---
kind: type
id: T:Autodesk.Revit.DB.Definition
source: html/8fe04f37-04e1-9e93-ffdb-e3900908e42a.htm
---
# Autodesk.Revit.DB.Definition

The Definition object is a base object for all type of parameter definitions within the Autodesk Revit API.

## Syntax (C#)
```csharp
public abstract class Definition
```

## Remarks
This object supports properties and methods that report the name and type of a
particular parameter. There are two kinds of definition object derived from this:
InternalDefinition which represents all kinds of definitions existing entirely within the
Autodesk Revit database. ExternalDefinitions represent definitions stored on disk in a
shared parameters file. Most of the time code should be written to utilize this Definition
base class as then the code will be applicable to both internal and external parameter
definitions.

