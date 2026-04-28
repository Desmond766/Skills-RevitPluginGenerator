---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.HasModifiedGeometry
zh: 族实例
source: html/0f1f1713-8013-2f62-6e84-41749e1dcc95.htm
---
# Autodesk.Revit.DB.FamilyInstance.HasModifiedGeometry Method

**中文**: 族实例

Identifies if the geometry of this FamilyInstance 
has been modified from the automatically generated default.

## Syntax (C#)
```csharp
public bool HasModifiedGeometry()
```

## Remarks
This method returns true if the geometry has been modified 
from post-processing activity in Revit such as joining, cutting, 
coping, extension, adaptive component modification, or other similar activity.

