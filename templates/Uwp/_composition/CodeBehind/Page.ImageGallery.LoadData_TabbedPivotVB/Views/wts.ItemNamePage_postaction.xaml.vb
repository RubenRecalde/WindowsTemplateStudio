﻿Namespace Views
    Public NotInheritable Partial Class wts.ItemNamePage
        Inherits Page

        Public Sub New()
            '{[{
            AddHandler Loaded, AddressOf wts.ItemNamePage_Loaded
            '}]}
        End Sub

        '{[{
        Private Async Sub wts.ItemNamePage_Loaded(sender As Object, e As RoutedEventArgs)            
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(wts.ItemNameSelectedIdKey)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(wts.ItemNameAnimationClose)
                If animation IsNot Nothing Then
                    Dim item = ImagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    ImagesGridView.ScrollIntoView(item)
                    Await ImagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(wts.ItemNameSelectedIdKey, String.Empty)
            End If
        End Sub
        '}]}
    End Class
End Namespace
