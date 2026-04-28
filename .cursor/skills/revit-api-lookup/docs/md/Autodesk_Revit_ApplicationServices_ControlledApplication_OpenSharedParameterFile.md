---
kind: method
id: M:Autodesk.Revit.ApplicationServices.ControlledApplication.OpenSharedParameterFile
source: html/6a8840aa-323f-3d4f-71cd-21be8da5af05.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.OpenSharedParameterFile Method

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

