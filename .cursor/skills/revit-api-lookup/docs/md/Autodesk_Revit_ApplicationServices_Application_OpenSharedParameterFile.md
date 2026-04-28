---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.OpenSharedParameterFile
source: html/e7698cec-f599-3078-f2e2-84e8d90f2b44.htm
---
# Autodesk.Revit.ApplicationServices.Application.OpenSharedParameterFile Method

Enables access to shared parameter groups and definitions that are maintained on disk.

## Syntax (C#)
```csharp
public DefinitionFile OpenSharedParameterFile()
```

## Returns
An object that represents a shared parameters file that exists on disk. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the file does not exist.

## Remarks
This function is used to return an object that represents a Revit shared parameters file
Revit can use only one shared parameters file at one time. The filename
for the shared parameters file can be set in the Application.SharedParametersFilename property.

