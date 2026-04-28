---
kind: type
id: T:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes
source: html/611ca5f7-3ffb-6f83-3aaf-df4533038ed0.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes

By-References dividing strategy used by PartMaker element.
 TODO_REFACTOR("LegacyMechanismOfMovingElements")
 returns true if
 - the Host Elements are not floors or walls
 - OR
 - the Host Elements that are referenced by this PartMaker are floors or walls
 - transformation has already been applied on those Host Elements

## Syntax (C#)
```csharp
public class PartMakerMethodToDivideVolumes : IDisposable
```

