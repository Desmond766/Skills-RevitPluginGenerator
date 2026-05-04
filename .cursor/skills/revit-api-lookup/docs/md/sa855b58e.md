---
kind: enumMember
id: F:Autodesk.Revit.Attributes.JournalingMode.NoCommandData
enum: Autodesk.Revit.Attributes.JournalingMode
source: html/fb11f6be-d1e2-728a-9c43-26ae89c8cc7c.htm
---
# Autodesk.Revit.Attributes.JournalingMode.NoCommandData

Does not write contents of the ExternalCommandData.Data map to the Revit journal. 
But does allow Revit API calls to write to the journal as needed. This option should allow commands
which invoke the Revit UI for selection or for responses to task dialogs to replay correctly.

