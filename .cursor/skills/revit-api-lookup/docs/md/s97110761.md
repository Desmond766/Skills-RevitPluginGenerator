---
kind: type
id: T:Autodesk.Revit.DB.ServerPath
source: html/c304ffcf-b3ae-46be-e361-a80bec83b5c0.htm
---
# Autodesk.Revit.DB.ServerPath

This class represents a path to a Revit Server location, rather than a
 location on disk or a network drive.

## Syntax (C#)
```csharp
public class ServerPath : ModelPath
```

## Remarks
ServerPaths must refer to Revit models. ServerPaths are relative to the central server location, and
 are of the form "RSN://{HostNodeName}/{model_path}". The {model_path} portion is a relative path to a Revit model.
 For example, the following are valid server paths: RSN://EXS/hospital.rvt RSN://EXS.autodesk.com/Old Files/hotel2.rvt RSN://EXS.autodesk.com/Old Files/Last Week/Tuesday\hotel2.rvt 
 The following would not be valid server paths:
 //EXS/Old Files/.rvt EXS/hospital

