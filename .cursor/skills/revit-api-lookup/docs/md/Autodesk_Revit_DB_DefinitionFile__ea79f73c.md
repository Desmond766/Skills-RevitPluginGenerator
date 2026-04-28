---
kind: type
id: T:Autodesk.Revit.DB.DefinitionFile
source: html/c074c52e-a483-51ca-476c-55990a06295c.htm
---
# Autodesk.Revit.DB.DefinitionFile

The DefinitionFile object represents a shared parameters file on disk.

## Syntax (C#)
```csharp
public class DefinitionFile : APIObject
```

## Remarks
Shared Parameters are parameter definitions that are stored in a text file
external to the Autodesk Revit project. These definitions can be used in multiple projects
and are identifiable by a unique identifier generated when they are created. API access to
shared parameters consist of a number of objects, the first of which is an object that
represents the shared parameters file on disk. That object then contains a number of Group
objects. Shared parameters are grouped for easier management. These groups then contain the
shared parameter definitions. The groups support the ability to create new shared
parameter definitions. The DefinitionFile object can be retrieved by the
Application.OpenSharedParameterFile method.

