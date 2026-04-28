---
kind: type
id: T:Autodesk.Revit.DB.ChangePriority
source: html/9db16841-106b-23bb-0c29-42017edcf69f.htm
---
# Autodesk.Revit.DB.ChangePriority

Enum used to specify the priority of an Updater during execution.

## Syntax (C#)
```csharp
public enum ChangePriority
```

## Remarks
The enumeration values are ordered in the order in which updaters associated to each
 priority will be run. For example, updaters associated to priority GridsLevelsReferencePlanes
 will run first, while updaters associated to priority Annotations will run last.

