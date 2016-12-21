
sqlite - c#
http://blog.tigrangasparian.com/2012/02/09/getting-started-with-sqlite-in-c-part-one/


http://www.altcontroldelete.pl/artykuly/c-wpf-oraz-sqlite-razem-w-jednym-projekcie/

Nie dziala dziadostwo


poprzedni XAML

<Page x:Class="Sqlite_Test.Page1"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    Title="Page1">
    <Grid>
        
    </Grid>
</Page>

---------------------------------------------
zamienione		SQLiteExample			Sqlite_Test
				MainWindow				Page1
				Window					Page
---------------------------------------------
<Page x:Class="Sqlite_Test.Page1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Page1" Height="350" Width="525" Closing="Window_Closing">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <ListView Grid.Row="0" Margin="5"
            x:Name="lstItems" ItemsSource="{Binding}">
            <ListView.View>
                <GridView AllowsColumnReorder="True">
                    <GridViewColumn>
                        <GridViewColumn.HeaderTemplate>
                            <DataTemplate >
                                <TextBlock Text="Id" Margin="2" />
                            </DataTemplate>
                        </GridViewColumn.HeaderTemplate>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Margin="2"
                                        Text="{Binding Path=PersonId}" />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn>
                        <GridViewColumn.HeaderTemplate>
                            <DataTemplate>
                                <TextBlock Text="Imiê" Margin="2" />
                            </DataTemplate>
                        </GridViewColumn.HeaderTemplate>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Margin="2"
                                        Text="{Binding Path=PersonName}" />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn>
                        <GridViewColumn.HeaderTemplate>
                            <DataTemplate>
                                <TextBlock Text="Nazwisko" Margin="2" />
                            </DataTemplate>
                        </GridViewColumn.HeaderTemplate>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Margin="2"
                                        Text="{Binding Path=PersonLastName}" />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn>
                        <GridViewColumn.HeaderTemplate>
                            <DataTemplate>
                                <TextBlock Text="Wiek" Margin="2" />
                            </DataTemplate>
                        </GridViewColumn.HeaderTemplate>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Margin="2"
                                        Text="{Binding Path=PersonAge}" />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
        <WrapPanel Grid.Row="1">
            <Button Content="Dodaj" x:Name="btnAdd" Margin="5"
                Click="btnAdd_Click" />
            <Button Content="Edytuj" x:Name="btnEdit" Margin="5"
                Click="btnEdit_Click" />
            <Button Content="Usuñ" x:Name="btnDelete" Margin="5"
                Click="btnDelete_Click" />
        </WrapPanel>
    </Grid>
</Window>


----------------------------------------------

