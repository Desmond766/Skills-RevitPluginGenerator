---
kind: method
id: M:Autodesk.Revit.DB.Face.GetRegions
source: html/9bde5f26-f830-7fca-39aa-792f9ac7caa5.htm
---
# Autodesk.Revit.DB.Face.GetRegions Method

Gets the face regions (created, for example, by the Split Face command) of the face.

## Syntax (C#)
```csharp
public IList<Face> GetRegions()
```

## Returns
A list of faces, one for the main face of the object hosting the Split Face (such as wall or floor) 
and one face for each Split Face regions.

## Remarks
Use the FaceSplitter class to filter and find elements which may generate face regions.

