---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnRPC(Autodesk.Revit.DB.RPCNode)
source: html/f84574d9-ef15-c317-c6dd-91304a0c174c.htm
---
# Autodesk.Revit.DB.IExportContext.OnRPC Method

This method marks the beginning of export of an RPC object.

## Syntax (C#)
```csharp
void OnRPC(
	RPCNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.RPCNode`) - A node with asset information about the RPC object.

## Remarks
This method is only called for photo-rendering export (a custom exporter that implements IPhotoRenderContext ).
 When an RPC object is encountered for a model context export (a custom exporter that implements IModelExportContext ),
 the RPC object will be provided as a polymesh (via OnPolymesh(PolymeshTopology) ).

