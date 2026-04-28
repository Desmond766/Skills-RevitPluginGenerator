---
kind: method
id: M:Autodesk.Revit.DB.MEPSystem.IsSystemDividable
zh: 系统
source: html/4764bc4f-7ca7-820e-2b06-ac1a25750971.htm
---
# Autodesk.Revit.DB.MEPSystem.IsSystemDividable Method

**中文**: 系统

Checks if the system is dividable. The system is dividable if there is more than one physical network in the system. Currently, only HVAC and piping systems support dividing.

## Syntax (C#)
```csharp
public bool IsSystemDividable()
```

## Returns
True if the system can be divided.

