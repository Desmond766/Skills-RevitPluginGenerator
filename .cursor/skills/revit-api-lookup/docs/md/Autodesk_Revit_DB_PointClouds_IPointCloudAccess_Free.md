---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointCloudAccess.Free
source: html/ef327efa-040b-8a37-079a-0481d8cc690a.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudAccess.Free Method

Completes the lifetime of the object providing this interface.

## Syntax (C#)
```csharp
void Free()
```

## Remarks
Calling this function indicates that the IPointCloudAccess interface is not going to be used
 after the call returns, and the provider of the interface can dispose of all allocated resources.

