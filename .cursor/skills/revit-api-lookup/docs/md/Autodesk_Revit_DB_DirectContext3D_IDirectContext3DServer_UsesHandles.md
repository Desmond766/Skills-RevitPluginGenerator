---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.UsesHandles
source: html/2d7066d3-e4a9-1c5e-05d0-e13943f8ea60.htm
---
# Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.UsesHandles Method

Tests whether this server uses DirectContext3D handle elements.

## Syntax (C#)
```csharp
bool UsesHandles()
```

## Returns
True if the server needs to use DirectContext3D handle elements, false otherwise.

## Remarks
In the current release servers that use handle elements can only work with internal addins. Third-party implementers should return 'false'.

