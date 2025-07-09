import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { Box, Card } from '@mui/material';

interface ContainerProps {
  title: string
  showActionButton?: boolean
  actionButtonLabel?: string
  onActionButtonClick?(): void
  children: React.ReactNode;
}

export default function ContentBox(props: ContainerProps) {

  const renderActionButton = () => {
    if (props.showActionButton) {
      return <Button variant="outlined" color="secondary" onClick={props.onActionButtonClick}>{props.actionButtonLabel}</Button>
    }
  }
  return (
    <Box sx={{ px: 12 }}>
      <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', mb: 1 }}>
        <Typography variant="h6">{props.title}</Typography>
        {renderActionButton()}
      </Box>
      <Card>
        {props.children}
      </Card>
    </Box>
  );
}